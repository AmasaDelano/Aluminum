(function () {
    "use strict";

    var app = angular.module("costumeselector", []);

    app.controller("QuestionController", ['$http', function ($http) {
        var questions = [],
            costumes = [],
            answered = [],
            currentQuestionIndex = 0,
            started = false,
            errored = false,
            getCurrentQuestion = function () {
                return questions[currentQuestionIndex];
            },
            toInt = function (value) {
                var type = typeof value;
                if (type === 'boolean') {
                    // Apparently it's faster to use the equals sign than not to.
                    // http://jsperf.com/boolean-int-conversion/2
                    return value === true ? 1 : 0;
                }
                if (type === 'number') {
                    return value;
                }
                return 0;
            },
            revisitQuestion = function (question) {
                var questionIndex = questions.indexOf(question),
                    answeredIndex = answered.indexOf(question);
                currentQuestionIndex = questionIndex;
                answered.length = answeredIndex;
            },
            answerQuestion = function (questionIndex, answer, text) {
                var question = questions[questionIndex];
                question.answerValue = answer;
                if (text) {
                    question.answeredText = text + question.answered;
                } else {
                    question.answeredText = question.answered;
                }
                answered.push(question);
            },
            answerMatchesCostume = function (answer, costume) {
                var matches,
                    costumeAnswer = costume[answer.dataField],
                    answerAnswer = answer.answerValue,
                    index;

                if (costumeAnswer && costumeAnswer.length > 0) {
                    matches = false;
                    for (index = 0; index < costumeAnswer.length; index += 1) {
                        if (toInt(costumeAnswer[index]) === toInt(answerAnswer)) {
                            matches = true;
                            break;
                        }
                    }
                } else {
                    matches = toInt(costumeAnswer) === toInt(answerAnswer);
                }

                return matches;
            },
            getPossibleCostumes = function () {
                var possibleCostumes = [],
                    costumeIndex,
                    costume,
                    answerIndex,
                    answer,
                    possible;

                for (costumeIndex = 0; costumeIndex < costumes.length; costumeIndex += 1) {
                    costume = costumes[costumeIndex];
                    possible = true;
                    for (answerIndex = 0; answerIndex < answered.length; answerIndex += 1) {
                        answer = answered[answerIndex];
                        if (!answerMatchesCostume(answer, costume) &&
                                costume[answer.dataField] !== null &&
                                answer.answerValue !== null) {
                            possible = false;
                            break;
                        }
                    }
                    if (possible) {
                        possibleCostumes.push(costume);
                    }
                }

                return possibleCostumes;
            },
            getIndexOfHighestItem = function (array) {
                var index,
                    highestItem = 0,
                    indexOfHighestItem = 0;

                for (index = 0; index < array.length; index += 1) {
                    if (array[index] > highestItem) {
                        highestItem = array[index];
                        indexOfHighestItem = index;
                    }
                }

                return indexOfHighestItem;
            },
            getQuestionRatings = function (possibleCostumes) {
                var questionIndex,
                    question,
                    costumeIndex,
                    costume,
                    ratingIndex,
                    rating,
                    valueIndex,
                    answerValue,
                    questionRatings = [];

                // Initialize the question ratings array with an array for each question.
                for (questionIndex = 0; questionIndex < questions.length; questionIndex += 1) {
                    questionRatings[questionIndex] = [];
                }

                // Increment the question-answer rating for each
                for (questionIndex = 0; questionIndex < questions.length; questionIndex += 1) {
                    question = questions[questionIndex];
                    if (answered.indexOf(question) === -1) {
                        for (costumeIndex = 0; costumeIndex < possibleCostumes.length; costumeIndex += 1) {
                            costume = possibleCostumes[costumeIndex];
                            answerValue = costume[question.dataField];
                            rating = questionRatings[questionIndex];
                            if (answerValue && answerValue.length > 0) {
                                for (valueIndex = 0; valueIndex < answerValue.length; valueIndex += 1) {
                                    if (rating[toInt(answerValue[valueIndex])] === undefined) {
                                        rating[toInt(answerValue[valueIndex])] = 0;
                                    }
                                    rating[toInt(answerValue[valueIndex])] += 1;
                                }
                            } else {
                                if (rating[toInt(answerValue)] === undefined) {
                                    rating[toInt(answerValue)] = 0;
                                }
                                rating[toInt(answerValue)] += 1;
                            }
                        }
                    }
                }

                // Transform the ratings from incremented numbers to actual ratings
                // (Closer to the middle is better.)
                for (questionIndex = 0; questionIndex < questionRatings.length; questionIndex += 1) {
                    rating = questionRatings[questionIndex];
                    for (ratingIndex = 0; ratingIndex < rating.length; ratingIndex += 1) {
                        rating[ratingIndex] =
                            possibleCostumes.length -
                            Math.abs(possibleCostumes.length - rating[ratingIndex] * 2);
                    }
                }

                // Take the highest value for each question, and make that the rating.
                for (questionIndex = 0; questionIndex < questionRatings.length; questionIndex += 1) {
                    questionRatings[questionIndex] =
                        questionRatings[questionIndex][getIndexOfHighestItem(questionRatings[questionIndex])] || 0;
                }

                return questionRatings;
            },
            getNextQuestionIndex = function () {
                var questionRatings = [],
                    possibleCostumes,
                    bestQuestionIndex,
                    ratingIndex,
                    oneRatingIsGood;

                // If there is only one costume that fits the criteria, we are done.
                possibleCostumes = getPossibleCostumes();

                if (possibleCostumes.length === 1) {
                    return -1;
                }

                questionRatings = getQuestionRatings(possibleCostumes);

                oneRatingIsGood = false;
                for (ratingIndex = 0; ratingIndex < questionRatings.length; ratingIndex += 1) {
                    if (questionRatings[ratingIndex] > 0) {
                        oneRatingIsGood = true;
                        break;
                    }
                }

                if (!oneRatingIsGood) {
                    return -1;
                }

                bestQuestionIndex = getIndexOfHighestItem(questionRatings);

                if (answered.indexOf(questions[bestQuestionIndex]) !== -1) {
                    return -1;
                }

                return bestQuestionIndex;
            },
            answerCurrentQuestion = function (answer, text) {
                answerQuestion(currentQuestionIndex, toInt(answer), text);
                currentQuestionIndex = getNextQuestionIndex();
            },
            hasQuestionsLeft = function () {
                return questions.length > currentQuestionIndex && currentQuestionIndex >= 0;
            },
            isLoading = function () {
                return questions.length === 0 || costumes.length === 0;
            },
            getBestCostumes = function () {
                if (hasQuestionsLeft()) {
                    return [];
                }

                var possibleCostumes = getPossibleCostumes();
                return possibleCostumes;
            },
            hasStarted = function () {
                return started;
            },
            hasErrored = function () {
                return errored;
            },
            start = function () {
                started = true;
            };

        // Get question and costume data from the server.
        $http.get("/api/costumeApi/GetQuestions").success(function (data) {
            questions = data;
            if (costumes.length > 0) {
                currentQuestionIndex = getNextQuestionIndex();
            }
        }).error(function () {
            errored = true;
        });
        $http.get("/api/costumeApi/GetCostumes").success(function (data) {
            costumes = data;
            if (questions.length > 0) {
                currentQuestionIndex = getNextQuestionIndex();
            }
        }).error(function () {
            errored = true;
        });

        this.getCurrentQuestion = getCurrentQuestion;
        this.answered = answered;
        this.answerCurrentQuestion = answerCurrentQuestion;
        this.hasQuestionsLeft = hasQuestionsLeft;
        this.revisitQuestion = revisitQuestion;
        this.getBestCostumes = getBestCostumes;
        this.isLoading = isLoading;
        this.hasErrored = hasErrored;
        this.hasStarted = hasStarted;
        this.start = start;
    }]);
}());