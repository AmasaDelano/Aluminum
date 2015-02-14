(function () {
    "use strict";

    var app = angular.module("costumeselector", []);

    app.controller("QuestionController", ['$http', function ($http) {
        var that = this,
            questions = [],
            costumes = [],
            answered = [],
            currentQuestionIndex = -1,
            getCurrentQuestion = function () {
                return questions[currentQuestionIndex];
            },
            toInt = function (value) {
                if (typeof value === 'boolean') {
                    return value ? 1 : 0;
                }
                return value;
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
                        if (toInt(costume[answer.dataField]) !== toInt(answer.answerValue) &&
                                costume[answer.dataField] !== null) {
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
                            answerValue = toInt(costume[question.dataField]);
                            rating = questionRatings[questionIndex];
                            if (rating[answerValue] === undefined) {
                                rating[answerValue] = 0;
                            }
                            rating[answerValue] += 1;
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
                        questionRatings[questionIndex][getIndexOfHighestItem(questionRatings[questionIndex])];
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
            getBestCostume = function () {
                var possibleCostumes = getPossibleCostumes();
                return possibleCostumes[0];
            };

        // Get question and costume data from the server.
        $http.get("/api/costumeApi/GetQuestions").success(function (data) {
            questions = data;
            if (costumes.length > 0) {
                currentQuestionIndex = getNextQuestionIndex();
            }
        }).error(function () {
            alert("Problem getting questions.");
        });
        $http.get("/api/costumeApi/GetCostumes").success(function (data) {
            costumes = data;
            if (questions.length > 0) {
                currentQuestionIndex = getNextQuestionIndex();
            }
        }).error(function () {
            alert("Problem getting costumes.");
        });

        that.getCurrentQuestion = getCurrentQuestion;
        that.answered = answered;
        that.answerCurrentQuestion = answerCurrentQuestion;
        that.hasQuestionsLeft = hasQuestionsLeft;
        that.revisitQuestion = revisitQuestion;
        that.getBestCostume = getBestCostume;
        that.isLoading = isLoading;

        return that;
    }]);
}());